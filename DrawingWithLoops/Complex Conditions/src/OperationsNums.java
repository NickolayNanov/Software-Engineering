import java.util.Scanner;

public class OperationsNums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num01 = Integer.parseInt(scanner.nextLine());
        int num02 = Integer.parseInt(scanner.nextLine());
        char symbol = scanner.next().charAt(0);

        if (symbol == '+') {
            int result = num01 + num02;
            if (result % 2 == 0) {
                System.out.println(num01 + " + " + num02 + " = " + result + " - " + "even");
            } else {
                System.out.println(num01 + " + " + num02 + " = " + result + " - " + "odd");
            }
        } else if (symbol == '-') {
            int result = num01 - num02;
            if (result % 2 == 0) {
                System.out.println(num01 + " - " + num02 + " = " + result + " - " + "even");
            } else {
                System.out.println(num01 + " - " + num02 + " = " + result + " - " + "odd");
            }
        } else if (symbol == '*') {
            int result = num01 * num02;
            if (result % 2 == 0) {
                System.out.println(num01 + " * " + num02 + " = " + result + " - " + "even");
            } else {
                System.out.println(num01 + " * " + num02 + " = " + result + " - " + "odd");
            }
        } else if (symbol == '/') {
            double result = num01 * 1.0 / num02;
            if (num02 == 0) {
                System.out.println("Cannot divide " + num01 + " by zero");
            } else if(result % 2 == 0) {
                System.out.print(num01 + " / " + num02 + " = ");
                System.out.printf("%.2f", result);
            }else{
                System.out.print(num01 + " / " + num02 + " = ");
                System.out.printf("%.2f", result);
            }
        } else if (symbol == '%') {
            double result = num01 * 0.1 % num02;
            if (num02 == 0) {
                System.out.println("Cannot divide " + num01 + " by zero");
            } else if(result % 2 == 0){
                System.out.println(num01 + " % " + num02 + " = " + (int)result);
            }else {
                System.out.println(num01 + " % " + num02 + " = " + (int)result);
            }
        }
    }
}