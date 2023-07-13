export class answerclass {

    id:number;
    answer:string;
    question:string;
    option1:string;
    option2:string;
    option3:string;
    option4:string;
    quizquestions:any;
    questionId:number;

    constructor()
    {
        this.id=0;
        this.answer="";
        this.option1="";
        this.option2="";
        this.option3="";
        this.option4="";
        this.question=""
        this.quizquestions=null;
        this.questionId=0;
    }
}
