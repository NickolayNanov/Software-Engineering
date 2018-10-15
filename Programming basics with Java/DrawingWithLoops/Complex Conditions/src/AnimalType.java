import java.util.Scanner;

public class AnimalType {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String animal = scanner.nextLine();

        switch (animal){
            case "dog":
                animal = "mammal";
                break;
            case "crocodile":
                animal ="reptile";
                break;
            case "tortoise":
                animal = "reptile";
                break;
            case "snake":
                animal = "reptile";
                break;
            default: animal = "unknown";
        }
        System.out.println(animal);
    }
}
