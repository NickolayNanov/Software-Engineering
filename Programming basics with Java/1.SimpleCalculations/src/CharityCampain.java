import java.util.Scanner;

public class CharityCampain {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int yearDays = Integer.parseInt(scanner.nextLine());
        int sweets = Integer.parseInt(scanner.nextLine());
        int cakes = Integer.parseInt(scanner.nextLine());
        int burette = Integer.parseInt(scanner.nextLine());
        int pancaces = Integer.parseInt(scanner.nextLine());

        double cakePrice = 45;
        double burettePice = 5.80;
        double pancakePice = 3.20;


        double CakesFinal = cakes * cakePrice;
        double BuretteFinal = burette * burettePice;
        double PancakesFinal = pancaces * pancakePice;

        double sumForDay = (CakesFinal + BuretteFinal + PancakesFinal) * sweets;
        double SumCollected = sumForDay * yearDays;
        double Payoffs = SumCollected - (SumCollected / 8);

        System.out.printf("%.2f", Payoffs);
    }
}
