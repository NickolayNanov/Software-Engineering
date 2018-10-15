import java.util.Scanner;

public class equalNums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num01 = Integer.parseInt(scanner.nextLine());
        int num02 = Integer.parseInt(scanner.nextLine());
        int num03 = Integer.parseInt(scanner.nextLine());

        if(num01 == num02 && num02 == num03 && num01 == num03){
            System.out.println("yes");
        }else{
            System.out.println("no");
        }
    }
}
