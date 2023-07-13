using Domain.Entity;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    internal class ValidationException : Exception
    {
        private List<ValidationFailure> failures;

        public ValidationException(List<FluentValidation.Results.ValidationFailure> failures)
        {
        }

        public ValidationException(List<ValidationFailure> failures)
        {
            this.failures = failures;
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        internal class RegistrationValidator
        {
            public static void ValidateRegistration(Register register)
            {
                List<ValidationFailure> failures = new List<ValidationFailure>();
                if (string.IsNullOrEmpty(register.Email))
                {
                    failures.Add(new ValidationFailure("Password is required."));
                }
                if (string.IsNullOrEmpty(register.UserName))
                {
                    failures.Add(new ValidationFailure("Username is required."));
                }

                if (string.IsNullOrEmpty(register.Password))
                {
                    failures.Add(new ValidationFailure("Password is required."));
                }
                else if (register.Password.Length < 8)
                {
                    failures.Add(new ValidationFailure("Password must be at least 8 characters long."));
                }

                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);
                }
            }
        }

        internal class ValidationFailure
        {
            public string ErrorMessage { get; }

            public ValidationFailure(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}