import java.util.Scanner;

public class EncodedAnswers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numInput = Integer.parseInt(scanner.nextLine());

        int AnswerA = 0;
        int AnswerB = 0;
        int AnswerC = 0;
        int AnswerD = 0;

        String result = " ";
        for (int questions = 0; questions < numInput; questions++) {
            String answer = "";
            long numbers = Long.parseLong(scanner.nextLine());
            if(numbers % 4 == 0){
                AnswerA++;
                answer = "a";
            }else if(numbers % 4 == 1){
                AnswerB++;
                answer = "b";
            }else if(numbers % 4 == 2){
                AnswerC++;
                answer = "c";
            }else if(numbers % 4 == 3){
                AnswerD++;
                answer = "d";
            }
            result += answer + ' ';
        }
        System.out.println(result);
        System.out.println("Answer A: " + AnswerA);
        System.out.println("Answer B: " + AnswerB);
        System.out.println("Answer C: " + AnswerC);
        System.out.println("Answer D: " + AnswerD);
    }
}
