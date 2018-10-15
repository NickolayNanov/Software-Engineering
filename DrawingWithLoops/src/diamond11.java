import java.util.Scanner;

public class diamond11 {
    public static void main(String[] args) {
        Scanner sacanner = new Scanner(System.in);

        int n = Integer.parseInt(sacanner.nextLine());

        int dashes = (n-1)/2;

        for (int i = 1; i < dashes; i++) {
            String dash = repeat("-",dashes);
            System.out.println(dash + "*");

            int mid = n-2 * dashes - 2;
            if(mid>=0){
                String middle = repeat("-",mid);
                System.out.println(middle + "*");
            }
            String dashess = repeat("-", dashes);
            dashes--;
        }

        for (int i = 0; i < 5; i++) {

        }
    }
    public static String repeat(String str, int times) {
        return new String(new char[times]).replace("\0", str);
    }
}
