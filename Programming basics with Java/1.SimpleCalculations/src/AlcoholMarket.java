import java.util.Scanner;

public class AlcoholMarket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double WiskeyPrice = Double.parseDouble(scanner.nextLine());

        double BeerQuantity = Double.parseDouble(scanner.nextLine());
        double WineQuantity = Double.parseDouble(scanner.nextLine());
        double RakiaQuantity = Double.parseDouble(scanner.nextLine());
        double WiskeyQuantity = Double.parseDouble(scanner.nextLine());

        double RakiaPrice = WiskeyPrice / 2;
        double WinePrice = RakiaPrice - (RakiaPrice * 40 / 100);
        double BeerPrice = RakiaPrice - (RakiaPrice * 80 / 100);

        double sumWiskey = WiskeyPrice * WiskeyQuantity;
        double sumBeer = BeerPrice * BeerQuantity;
        double sumWine = WinePrice * WineQuantity;
        double sumRakia = RakiaPrice * RakiaQuantity;

        double Bill = sumBeer + sumRakia + sumWiskey + sumWine;

        System.out.printf("%.2f", Bill);
    }
}
