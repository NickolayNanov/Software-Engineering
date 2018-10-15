import java.util.Scanner;

public class scholarship {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double incomeLV = Double.parseDouble(scanner.nextLine());
        double avarageMark = Double.parseDouble(scanner.nextLine());
        double MinimalSalary = Double.parseDouble(scanner.nextLine());

        double SocialScholarship = Math.floor(MinimalSalary * 35 / 100.0);
        double NormalScolarship = Math.floor(avarageMark * 25);

        String SS = "You get a Social scholarship";
        String ER = "You get a scholarship for excellent results";
        if (avarageMark >= 5.50) {
            System.out.println("You get a scholarship for excellent results"+ " " + (int)NormalScolarship + " " + "BGN");
        }else if (avarageMark >= 4.50 && incomeLV < MinimalSalary) {
            System.out.println("You get a Social scholarship" + " " + (int)SocialScholarship + " " + "BGN" );
        }  else {
            System.out.println("You cannot get a scholarship!");
        }

    }
}
