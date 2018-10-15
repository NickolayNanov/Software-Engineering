import java.util.Scanner;

public class SwimingRecord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double record = Double.parseDouble(scanner.nextLine());
        double distance = Double.parseDouble(scanner.nextLine());
        double time = Double.parseDouble(scanner.nextLine());

        double distanceToSwim = (distance * time);
        double distanceWithResistance = (Math.floor(distance / 15) * 12.5);

        double OverallTime = distanceToSwim + distanceWithResistance;


        if(OverallTime < record){
            System.out.printf("Yes, he succeeded! The new world record is %.2f", OverallTime);
            System.out.println(" seconds.");
        }else{
            System.out.printf("No, he failed! He was %.2f", (OverallTime-record));
            System.out.println(" seconds slower.");
        }

    }
}

