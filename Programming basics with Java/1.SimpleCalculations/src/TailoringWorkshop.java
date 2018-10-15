import java.util.Scanner;

public class TailoringWorkshop {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int tables = Integer.parseInt(scanner.nextLine());
        double LenghtTable = Double.parseDouble(scanner.nextLine());
        double WidthTable = Double.parseDouble(scanner.nextLine());

        double USD = 1.85;

        double RecArea = tables * (LenghtTable + 2 * 0.30) * (WidthTable + 2 * 0.30);
        double SquareArea = tables * (LenghtTable / 2) * (LenghtTable / 2);

        double priceUSD = (RecArea * 7) + (SquareArea * 9);
        double priceBGN = priceUSD * USD;

        System.out.printf("%.2f USD", priceUSD);
        System.out.println("");
        System.out.printf("%.2f BGN", priceBGN);



    }
}
