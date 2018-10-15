import java.util.Scanner;

public class Balls {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());

        int sum = 0;
        int red = 0;
        int orange = 0;
        int yellow = 0;
        int white = 0;
        int black = 0;
        int others = 0;

        for (int i = 1; i <= num; i++) {
            String colour = scanner.nextLine();

            if(colour.equals("red")){
                sum += 5;
                red++;
            }
           else if(colour.equals("orange")){
                sum += 10;
                orange++;
            }
           else if(colour.equals("yellow")){
                sum += 15;
                yellow++;
            }
           else if(colour.equals("white")){
                sum += 20;
                white++;
            }
           else if(colour.equals("black")){
                sum /= 2;
                black++;
            }
            else {
                others++;
            }
        }
        System.out.printf("Total points: %d", sum);
        System.out.println();
        System.out.printf("Points from red balls: %d", red);
        System.out.println();
        System.out.printf("Points from orange balls: %d", orange);
        System.out.println();
        System.out.printf("Points from yellow balls: %d", yellow);
        System.out.println();
        System.out.printf("Points from white balls: %d", white);
        System.out.println();
        System.out.printf("Other colors picked: %d", others);
        System.out.println();
        System.out.printf("Divides from black balls: %d", black);
    }
}
