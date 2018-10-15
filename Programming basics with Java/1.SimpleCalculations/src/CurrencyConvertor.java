import java.util.Scanner;

public class CurrencyConvertor {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double money = Double.parseDouble(scanner.nextLine());
        String input = scanner.nextLine();
        String output = scanner.nextLine();


        double toUSD = 1.79549;
        double toEUR = 1.95583;
        double toGBP = 2.53405;


        switch (input){
            case"BGN":
                break;
            case"EUR":
               money = money * toEUR;
                break;
            case"USD":
                money = money * toUSD;
                break;
            case"GBP":
                money = money * toGBP;
                break;
        }

         switch (output){
             case "BGN":
                 break;
             case "EUR":
                 money = money / toEUR;
                 break;
             case "USD":
                 money = money / toUSD;
                 break;
             case "GBP":
                 money = money / toGBP;
                 break;
         }

        double result = Math.round(money*100)/100.0;

        System.out.println(result + " " + output );
    }
}