import java.util.Scanner;

public class FruitShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String product = scanner.nextLine().toLowerCase();
        String day = scanner.nextLine().toLowerCase();
        double quantity = Double.parseDouble(scanner.nextLine());

        if(day.equals("monday") || day.equals("tuesday") || day.equals("wednesday") || day.equals("thursday") || day.equals("friday")){
            if(product.equals("banana")){
                System.out.println(2.50 * quantity);
            }else if(product.equals("apple")){
                System.out.println(1.20 * quantity);
            }else if(product.equals("orange")){
                System.out.println(0.85 * quantity);
            }else if(product.equals("grapefruit")){
                System.out.println(1.45 * quantity);
            }else if(product.equals("kiwi")){
                System.out.println(2.70 * quantity);
            }else if(product.equals("pineapple")){
                System.out.println(5.50 * quantity);
            }else if(product.equals("grapes")){
                System.out.println(3.85 * quantity);
            } else{
                System.out.println("error");
            }
        } else if(day.equals("saturday") || day.equals("sunday")){

            if(product.equals("banana")){
                System.out.println(2.70 * quantity);
            }else if(product.equals("apple")){
                System.out.println(1.25 * quantity);
            }else if(product.equals("orange")){
                System.out.println(0.90 * quantity);
            }else if(product.equals("grapefruit")){
                System.out.println(1.60 * quantity);
            }else if(product.equals("kiwi")){
                System.out.println(3.00 * quantity);
            }else if(product.equals("pineapple")){
                System.out.println(5.60 * quantity);
            }else if(product.equals("grapes")){
                System.out.println(4.20 * quantity);
            }else{
                System.out.println("error");
            }
        }else {
            System.out.println("error");
        }
    }
}
