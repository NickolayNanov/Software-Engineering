import java.util.Scanner;

public class SmartLili {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int yearsOld = Integer.parseInt(scanner.nextLine());
        double peralnq = Double.parseDouble(scanner.nextLine());
        double toyPrice = Double.parseDouble(scanner.nextLine());

        int money = 0;
        int toyCount = 0;
        int MoneyWithBrother = 0;

        for (int i = 1; i <= yearsOld ; i++) {
            if(i % 2 == 0){
                money += 10;
                MoneyWithBrother += money - 1;
            }else{
                toyCount += 1;
            }

        }

        double ToysIncome = toyCount * toyPrice;
        double savedMoney = ToysIncome + MoneyWithBrother;

        if(savedMoney >= peralnq){
            double result = savedMoney - peralnq;
            System.out.printf("Yes! %.2f", result);
        }else{
            double result = peralnq - savedMoney;
            System.out.printf("No! %.2f", result);
        }
    }
}
