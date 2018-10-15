import java.util.Scanner;

public class Choreography {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double steps = Double.parseDouble(scanner.nextLine());
        double dancers = Double.parseDouble(scanner.nextLine());
        double days = Double.parseDouble(scanner.nextLine());

        double stepsForDay = ((steps / days) / steps) * 100;
        double percantage = Math.ceil(stepsForDay);
        double percentForOne = ((percantage / dancers)*100.0)/100.0;
        if(stepsForDay <= 13){
            System.out.printf("Yes, they will succeed in that goal! %.2f", percentForOne);
            System.out.print("%.");
        }else{
            System.out.printf("No, They will not succeed in that goal! Required %.2f", percentForOne);
            System.out.print("% steps to be learned per day.");
        }
    }
}
