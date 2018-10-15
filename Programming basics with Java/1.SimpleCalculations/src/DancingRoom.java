import java.util.Scanner;

public class DancingRoom {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double roomLenght = Double.parseDouble(scanner.nextLine());
        double roomWidth = Double.parseDouble(scanner.nextLine());
        double wardrobeSide = Double.parseDouble(scanner.nextLine());

        double room = (roomLenght * 100) * (roomWidth * 100);
        double wardrobe = (wardrobeSide * 100) * (wardrobeSide * 100);
        double bench = room / 10;

        double freeSpace = room - (wardrobe + bench);
        double dancers = freeSpace / (40 + 7000);

        System.out.printf("%.0f", Math.floor(dancers));
    }

}
