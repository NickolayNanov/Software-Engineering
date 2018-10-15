import java.util.Scanner;


public class house {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        if(n%2 == 0){
            int asterix = 2;
            int dashes = (n-2)/2;

            for (int i = 0; i < (n+1)/2; i++) {
                System.out.printf("%s%s%s%n",
                        repeatStr("-", dashes),
                        repeatStr("*", asterix),
                        repeatStr("-", dashes));
                asterix+=2;
                dashes--;
            }

       }else{
            int asterix = 1;
            int dashes = (n-1)/2;
            for (int i = 0; i < (n+1)/2; i++) {
                System.out.printf("%s%s%s%n",
                        repeatStr("-", dashes),
                        repeatStr("*", asterix),
                        repeatStr("-", dashes));
                asterix+=2;
                dashes--;
            }
        }
        for (int i = 1; i <= n-2; i++) {
            System.out.print("|");
            for (int j = 1; j <= n-2; j++) {
                System.out.print("*");
            }
            System.out.println("|");

        }
       //roof

        }
    public static String repeat(String str, int times) {
        return new String(new char[times]).replace("\0", str);
    }


    public static String repeatStr(String str, int count) {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < count; i++) {
            sb.append(str);
        }
        return sb.toString();
    }
}
