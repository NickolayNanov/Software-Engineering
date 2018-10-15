import java.util.Scanner;

public class PicOnTheWall {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int widthHole = Integer.parseInt(scanner.nextLine());
        int lenghtHole = Integer.parseInt(scanner.nextLine());
        int picSide = Integer.parseInt(scanner.nextLine());
        int countPics = Integer.parseInt(scanner.nextLine());

        int hole = widthHole * lenghtHole;

        int quantityOfPics = (picSide * picSide) * countPics;

        if(hole >= quantityOfPics){
            int difference = hole - quantityOfPics;
            System.out.printf("The pictures fit in the hole. Hole area is %d bigger than pictures area.", difference);
        }else {
            int difference = quantityOfPics - hole;
            System.out.printf("The pictures don't fit in the hole. Picture area is %d bigger than hole area.", difference);
        }
    }
}
