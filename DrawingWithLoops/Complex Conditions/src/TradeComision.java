import java.util.Scanner;

public class TradeComision {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String city = scanner.nextLine().toLowerCase();
        double sales = Double.parseDouble(scanner.nextLine());
        double commision = -1;

        if (city.equals("sofia")) {
            if (0 <= sales && sales <= 500) {
                commision = 0.05 * sales;
            } else if(500 <= sales && sales <= 1000){
                commision = 0.07 * sales;
            }else if(1000 < sales && sales <= 10000){
                commision = 0.08 * sales;
            }else if(sales > 10000){
                commision = 0.12 * sales;
            }
        }else if(city.equals("varna")){
            if (0 <= sales && sales <= 500) {
                commision = 0.045 * sales;
            } else if(500 <= sales && sales <= 1000){
                commision = 0.075 * sales;
            }else if(1000 < sales && sales <= 10000){
                commision = 0.1 * sales;
            }else if(sales > 10000){
                commision = 0.13 * sales;
            }
        }else if(city.equals("plovdiv")){
            if (0 <= sales && sales <= 500) {
                commision = 0.055 * sales;
            } else if(500 <= sales && sales <= 1000){
                commision = 0.08 * sales;
            }else if(1000 < sales && sales <= 10000){
                commision = 0.12 * sales;
            }else if(sales > 10000){
                commision = 0.145 * sales;
            }
        }

        if(commision > 0){
            System.out.printf("%.2f", commision);
        }else {
            System.out.println("error");
        }

    }
}
