import java.util.Scanner;
public class MatchTickets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double bugget = Double.parseDouble(scanner.nextLine());
        String type = scanner.nextLine().toLowerCase();
        int countPeople = Integer.parseInt(scanner.nextLine());

        double vip = 499.99;
        double normal = 249.99;

                if(countPeople >= 1 && countPeople <= 4 ){
            double transport = bugget * 0.75;
            double Left = bugget - transport;
                if(type.equals("normal")){
                        double price = normal * countPeople;
                        double left =  Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", (left));
                            System.out.print(" leva left.");
                        }else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                } else if(type.equals("vip")){
                    double price = vip * countPeople;
                    double left =  Left - price;
                    if(price < Left){
                        System.out.printf("Yes! You have %.2f", left);
                        System.out.print(" leva left.");
                    }else {
                        double result = price - Left;
                        System.out.printf("Not enough money! You need %.2f", result);
                        System.out.print(" leva.");
                    }
                }
        } else if(countPeople >= 5 && countPeople <= 9){
            double transport = bugget * 0.60;
            double Left = bugget - transport;
                if(type.equals("normal")){
                    double price = normal * countPeople;
                    double left = Left - price;
                    if(price < Left){
                        System.out.printf("Yes! You have %.2f", left);
                        System.out.println(" leva left.");
                    }else {
                        double result = price - Left;
                        System.out.printf("Not enough money! You need %.2f", result);
                        System.out.print(" leva.");
                    }
                }else if(type.equals("vip")){
                    double price = vip * countPeople;
                    double left = Left - price;
                    if(price < Left){
                        System.out.printf("Yes! You have %.2f", left);
                        System.out.print(" leva left.");
                    } else {
                        double result = price - Left;
                        System.out.printf("Not enough money! You need %.2f", result);
                        System.out.print(" leva.");
                    }
                }

        } else if(countPeople >= 10 && countPeople <= 24){
            double transport = bugget * 0.50;
            double Left = bugget - transport;
                    if(type.equals("normal")){
                        double price = normal * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", left);
                            System.out.print(" leva left.");
                        }else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }else if(type.equals("vip")){
                        double price = vip * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", left);
                            System.out.print(" leva left.");
                        } else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }
        } else if(countPeople >= 25 && countPeople <= 49){
            double transport = bugget * 0.40;
            double Left = bugget - transport;
                    if(type.equals("normal")){
                        double price = normal * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", left);
                            System.out.print(" leva left.");
                        }else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }else if(type.equals("vip")){
                        double price = vip * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", left);
                            System.out.print(" leva left.");
                        } else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }
        } else if(countPeople > 50){
            double transport = bugget * 0.25;
            double Left = bugget - transport;
                    if(type.equals("normal")){
                        double price = normal * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f", left);
                            System.out.print(" leva left.");
                        }else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }else if(type.equals("vip")){
                        double price = vip * countPeople;
                        double left = Left - price;
                        if(price < Left){
                            System.out.printf("Yes! You have %.2f",  left);
                            System.out.print(" leva left.");
                        } else {
                            double result = price - Left;
                            System.out.printf("Not enough money! You need %.2f", result);
                            System.out.print(" leva.");
                        }
                    }
        }

    }
}
