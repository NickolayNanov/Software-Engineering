import java.util.Scanner;

public class StupidPasswordGenerator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int L = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                for (int k = 97; k < 97 + L; k++) {
                    for (int o = 97; o < 97 + L; o++) {
                        for (int m = 1; m <= n; m++) {

                            if(m > i && m > j){
                                System.out.printf("%d%d%s%s%d ", i, j, (char)k, (char)o, m);
                            }
                        }
                    }
                }
            }
        }
    }
}
