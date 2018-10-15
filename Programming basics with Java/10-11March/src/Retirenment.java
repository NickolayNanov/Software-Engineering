import java.util.Scanner;

public class Retirenment {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String gender = scanner.nextLine();
        int age = Integer.parseInt(scanner.nextLine());
        int experience = Integer.parseInt(scanner.nextLine());


                if (gender.equals("female")) {
                    if (age >= 61) {
                        if (experience >= 35) {
                            System.out.printf("Ready to retire at %d and %d years of experience!", age, experience);
                        }
                    } else if (age < 61) {
                        if (experience >= 35) {
                            int requiredAges = 61 - age;
                            System.out.printf("Worked enough, but not old enough. Years left to retirement: %d.", requiredAges);
                        }
                    } else if (age >= 61) {
                        if (experience < 35) {
                            int requiredExp = 35 - experience;
                            System.out.printf("Old enough, but haven't worked enough. Work experience left to retirement: %d.", requiredExp);
                        }
                    } else if (age < 61) {
                        if (experience < 35) {
                            int requiredExp = 35 - experience;
                            int requiredAges = 61 - age;
                            System.out.printf("Too early. Years left to retirement: %d. Work experience left to retirement: %d.", requiredAges, requiredExp);
                        }
                    }
                } else if (gender.equals("male")) {
                    if (age >= 64) {
                        if (experience >= 38) {
                            System.out.printf("Ready to retire at %d and %d years of experience!", age, experience);
                        }
                    }
                    if (age < 64) {
                        if (experience >= 38) {
                            int requiredAges = 64 - age;
                            System.out.printf("Worked enough, but not old enough. Years left to retirement: %d.", requiredAges);
                        }
                    }
                    if (age >= 64) {
                        if (experience < 38) {
                            int requiredExp = 38 - experience;
                            System.out.printf("Old enough, but haven't worked enough. Work experience left to retirement: %d.", requiredExp);
                        }
                    }
                    if (age < 64) {
                        if (experience < 38) {
                            int requiredExp = 38 - experience;
                            int requiredAges = 64 - age;
                            System.out.printf("Too early. Years left to retirement: %d. Work experience left to retirement: %d.", requiredAges, requiredExp);
                        }
                    }

                }else System.out.println("Invalid input.");
    }
}
