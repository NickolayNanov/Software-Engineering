import java.util.Scanner;

public class diamond {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = Integer.parseInt(scanner.nextLine());

        int rows = num;
        int leftRight = (num - 1) / 2;    //1
        int mid = num - 2 * leftRight - 2; //-1
        int lines = 0;

        if (num % 2 == 0) {

            for (int i = 0; i < (num / 2); i++) {
                System.out.println(repeatStr("-", ((num - 2) / 2) - i) + "*" + repeatStr("-", 2 * i) + "*" + repeatStr("-", ((num - 2) / 2) - i));
            }

            for (int i = (num / 2) - 2; i >= 0; i--) {
                System.out.println(repeatStr("-", ((num - 2) / 2) - i) + "*" + repeatStr("-", 2 * i) + "*" + repeatStr("-", ((num - 2) / 2) - i));
            }

        } else {

            for (int i = 0; i < (num / 2); i++) {
                if (i == 0) {
                    System.out.println(repeatStr("-", ((num - 1) / 2) - i) + "*" + repeatStr("-", ((num - 1) / 2) - i));
                } else {
                    System.out.println(repeatStr("-", ((num - 1) / 2) - i) + "*" + repeatStr("-", 2 * i - 1) + "*" + repeatStr("-", ((num - 1) / 2) - i));
                }
            }

            if (num == 1) {
                System.out.println("*");
            }
            if (num > 1) {
                System.out.println("*" + repeatStr("-", num - 2) + "*");
            }

            for (int i = (num / 2) - 1; i >= 0; i--) {
                if (i == 0) {
                    System.out.println(repeatStr("-", ((num - 1) / 2) - i) + "*" + repeatStr("-", ((num - 1) / 2) - i));
                } else {
                    System.out.println(repeatStr("-", ((num - 1) / 2) - i) + "*" + repeatStr("-", 2 * i - 1) + "*" + repeatStr("-", ((num - 1) / 2) - i));
                }

            }



        }

    }

    static String repeatStr(String str, int count) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(str);
        }
        return sb.toString();
    }

}