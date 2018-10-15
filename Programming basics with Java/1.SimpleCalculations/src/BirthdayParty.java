import java.util.Scanner;

public class BirthdayParty {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int lenght = Integer.parseInt(scanner.nextLine());
        int widht = Integer.parseInt(scanner.nextLine());
        int height = Integer.parseInt(scanner.nextLine());
        double percent = Double.parseDouble(scanner.nextLine());

        double Volume = lenght*widht*height;
        double OverallVolume = Volume*0.001;
        double Percentage = percent*0.01;

        double result = OverallVolume*(1-Percentage);

        System.out.printf("%.3f", result);
    }


}
