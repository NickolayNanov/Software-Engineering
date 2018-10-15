import java.util.Scanner;

;

public class ChristmasTree {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

       int n = Integer.parseInt(scanner.nextLine());

       String TopSpaces = repeat(" ",n+1);
        System.out.println(TopSpaces + "|");

        for (int i = 1; i <= n; i++) {
            String spaces = repeat(" ",n-i);
            String asterix = repeat("*", i);
            System.out.println(spaces + asterix + " | " + asterix + spaces);
        }



    }
    public static String repeat(String str, int times) {
        return new String(new char[times]).replace("\0", str);
    }

}

