import java.util.Scanner;

public class ToyShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double excursionPrice = Double.parseDouble(scanner.nextLine());

        int puzzleQuantity = Integer.parseInt(scanner.nextLine());
        int dollsQuantity = Integer.parseInt(scanner.nextLine());
        int bearsQuantity = Integer.parseInt(scanner.nextLine());
        int minionsQuantity = Integer.parseInt(scanner.nextLine());
        int trucksQuantity = Integer.parseInt(scanner.nextLine());

        double puzzlePrice = 2.60;
        double dollPrice = 3.0;
        double bearPrice = 4.10;
        double minionPrice = 8.20;
        double truckPrice = 2.0;

        double price = (puzzleQuantity*puzzlePrice)+(dollsQuantity*dollPrice)+(bearPrice*bearsQuantity)+(minionPrice*minionsQuantity)+(truckPrice*trucksQuantity);
        double toysQuantity = puzzleQuantity+dollsQuantity+bearsQuantity+minionsQuantity+trucksQuantity;



        double priceWithDoscount = 0.0;
        if(toysQuantity >= 50){
            price = price - 0.25*price;
            price = price - price * 0.1;
        }

        if(price >= excursionPrice){
            System.out.printf("Yes! %.2f", (price - excursionPrice));
            System.out.print(" lv left.");
        }else{
            System.out.printf("Not enough money! %.2f", (excursionPrice - price));
            System.out.print(" lv needed.");
        }
    }
}
