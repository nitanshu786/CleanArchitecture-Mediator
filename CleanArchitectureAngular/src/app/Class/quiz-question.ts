export class QuizQuestion {
   id:Number;
   question:string;
   questionNumber:string;
   option1:string;
   option2:string;
   option3:string;
   option4:string;
  //  timer:any;
  //  remainingTime:any;
   correctAnswer:string;


    constructor()
    {
      this.id=0;
      this.question="";
      this.questionNumber=""
      this.option1="";
      this.option2="";
      this.option3="";
      this.option4="";
      // this.timer=null;
      // this.remainingTime=null;
      this.correctAnswer=""
    }
}
