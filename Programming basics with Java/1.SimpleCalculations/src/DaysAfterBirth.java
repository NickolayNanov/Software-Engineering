
import java.util.Scanner;
import java.time.LocalDate;
import java.time.format.*;
public class DaysAfterBirth {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);


        String data = scanner.nextLine();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy");

        LocalDate parsedDate = LocalDate.parse(data, formatter);
        LocalDate after1000 = parsedDate.plusDays(999);

        System.out.println(after1000.format(formatter));
    }
}
