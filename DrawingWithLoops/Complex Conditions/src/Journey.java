import java.util.Scanner;

public class Journey {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double bugget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        if(bugget <= 100 ){
            if(season.equals("summer")){
                System.out.println("Somewhere in Bulgaria");
                System.out.printf("Camp - %.2f", 0.3 * bugget);
            }else if(season.equals("winter")){
                System.out.println("Somewhere in Bulgaria");
                System.out.printf("Hotel - %.2f", 0.7 * bugget );
            }
        }else if(bugget <= 1000 && bugget < 10000){
            if(season.equals("summer")){
                System.out.println("Somewhere in Balkans");
                System.out.printf("Camp - %.2f", 0.4 * bugget);
            }else if(season.equals("winter")){
                System.out.println("Somewhere in Balkans");
                System.out.printf("Hotel - %.2f", 0.8 * bugget);
            }
        }else if(bugget > 1000){
            System.out.println("Somewhere in Europe");
            System.out.printf("Hotel - %.2f", 0.9 * bugget);
        }
    }
}
