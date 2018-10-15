    import java.util.Scanner;

    public class Sunglasses {
        public static void main(String[] args) {
            Scanner scanner = new Scanner(System.in);

            int n = Integer.parseInt(scanner.nextLine());

            for (int row = 1; row <= n*2; row++) {
                System.out.print("*");
            }

            for (int spaces = 1; spaces <= n; spaces++) {
                System.out.print(" ");
            }

            for (int row = 1; row <= n*2 ; row ++) {
                System.out.print("*");
            }
            System.out.println("");

            //1st--------------

            for (int row = 0; row < n-2; row++) {
                if(row == (n-1) / 2 - 1){
                System.out.print("*");
                for (int col = 1; col <= 2*n-2 ; col++) {
                    System.out.print("/");
                }
                System.out.print("*");
                for (int i = 1; i <= n ; i++) {
                    System.out.print("|");
                }
                System.out.print("*");
                for (int col = 1; col <= 2*n-2 ; col++) {
                    System.out.print("/");
                }
                System.out.print("*");
                System.out.println("");
            }else{
                    System.out.print("*");
                    for (int col = 1; col <= 2*n-2 ; col++) {
                        System.out.print("/");
                    }
                    System.out.print("*");
                    for (int i = 1; i <= n ; i++) {
                        System.out.print(" ");
                    }
                    System.out.print("*");
                    for (int col = 1; col <= 2*n-2 ; col++) {
                        System.out.print("/");
                    }
                    System.out.print("*");
                    System.out.println("");
                }




            }


             //end------------
            for (int row = 1; row <= n*2; row++) {
                System.out.print("*");
            }

            for (int spaces = 1; spaces <= n; spaces++) {
                System.out.print(" ");
            }

            for (int row = 1; row <= n*2 ; row ++) {
                System.out.print("*");
            }
            System.out.print("");
        }
    }
