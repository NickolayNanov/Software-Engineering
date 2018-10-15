import java.util.Scanner;

public class Volleyball {

    public static void main(String[] args) {

        Scanner console = new Scanner(System.in);
        String year = console.nextLine().toLowerCase();
        int holidays = Integer.parseInt(console.nextLine());
        int travel = Integer.parseInt(console.nextLine());

        double weekends = -1;
        double freeWeekends = -1;
        double total = -1;
        double saturdayGames = -1;
        double holidayGames = -1;
        double totalPlus15 = -1;

        if (year.equals("leap")) {
            weekends = 48;
            freeWeekends = weekends - travel;
            saturdayGames = freeWeekends * 3.0/4;
            holidayGames = holidays * 2.0/3;
            total = saturdayGames + travel + holidayGames;
            totalPlus15 = total * 1.15;
            System.out.println(Math.floor(totalPlus15));
        } else if (year.equals("normal")) {
            weekends = 48;
            freeWeekends = weekends - travel;
            saturdayGames = freeWeekends * 3.0/4;
            holidayGames = holidays * 2.0/3;
            total = saturdayGames + travel + holidayGames;;
            System.out.println(Math.floor(total));
        }
    }
}