import java.util.Scanner;

public class Travel {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double aTob = Double.parseDouble(scanner.nextLine());
        double truckSpeed = Double.parseDouble(scanner.nextLine());
        double speedDifference = Double.parseDouble(scanner.nextLine());

        double carSpeedDifferenceKmHour = speedDifference * 3.6;
        double carkSpeed = carSpeedDifferenceKmHour + truckSpeed;


        double truckTimeTravelling = Math.ceil(aTob / truckSpeed);
        double carTimeTravelling = Math.ceil(aTob / carkSpeed);

        System.out.printf("The truck arrived after %.0f hours", truckTimeTravelling);
        System.out.println("");
        System.out.printf("The car arrived after %.0f hours", carTimeTravelling);


    }
}
