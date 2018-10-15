import java.util.Scanner;

public class Arrow {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int width = n + 5;

        System.out.printf("%s^%s%n",
                repeatStr("_", (width - 1) / 2),
                repeatStr("_", (width - 1) / 2));

        System.out.printf("%s/|\\%s%n",
                repeatStr("_", (width - 2) / 2),
                repeatStr("_", (width - 2) / 2));

        //Първи и Втори ред

        for (int row = 0; row < n / 2; row++) {
            System.out.printf("%s%s%s|||%s%s%s%n",
                    repeatStr("_", (width - 4) / 2 - row),
                    repeatStr("/", 1),
                    repeatStr(".", row),
                    repeatStr(".", row),
                    repeatStr("\\", 1),
                    repeatStr("_", (width - 4) / 2 - row));
        }

        System.out.printf("%s%s%s|||%s%s%s%n",
                repeatStr(""));
    }
    static String repeatStr (String str,int count){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(str);
        }
        return sb.toString();
    }
}
