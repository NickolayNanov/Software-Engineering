import java.util.Scanner;

public class FruitOrVegetable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();

        if(type.equals("banana")){
            System.out.println("fruit");
        }else if(type.equals("apple")){
            System.out.println("fruit");
        }else if(type.equals("kiwi")){
            System.out.println("fruit");
        }else if(type.equals("cherry")){
            System.out.println("fruit");
        }else if(type.equals("lemon")){
            System.out.println("fruit");
        }else if(type.equals("grapes")){
            System.out.println("fruit");
        }else if(type.equals("tomato")){
            System.out.println("vegetable");
        }else if(type.equals("cucumber")){
            System.out.println("vegetable");
        }else if(type.equals("pepper")){
            System.out.println("vegetable");
        }else if(type.equals("carrot")){
            System.out.println("vegetable");
        }else {
            System.out.println("unknown");
        }
    }


}
