import java.util.Scanner;

public class SimilarPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbersToRead = Integer.parseInt(scanner.nextLine());
        int currSum = 0;
        int prevSum = 0;
        int diff = 0;
        int maxDiff = 0;

        for (int i = 0; i < numbersToRead; i++) {
            prevSum = currSum;
            currSum = 0;
            currSum += Integer.parseInt(scanner.nextLine());
            currSum += Integer.parseInt(scanner.nextLine());

            if(i != 0){
                diff = Math.abs(currSum - prevSum);
                if(diff != 0 && diff > maxDiff){
                    maxDiff = diff;
                }
            }

            if(prevSum == currSum || numbersToRead == 1){
                System.out.printf("Yes, Value=%d", currSum);
            }else {
                System.out.printf("No,maxdiff=%d", maxDiff);
            }

        }
    }
}
