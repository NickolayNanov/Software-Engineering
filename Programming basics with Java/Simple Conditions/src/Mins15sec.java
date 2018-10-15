    import java.util.Scanner;

    public class Mins15sec {
        public static void main(String[] args) {
            Scanner scanner = new Scanner(System.in);

            int hour = Integer.parseInt(scanner.nextLine());
            int min = Integer.parseInt(scanner.nextLine());

            int minAfter15 = min + 15;


            if(minAfter15 > 59){
                hour++;
            }else if(minAfter15 > 120){
                hour = 2;
            }else if(minAfter15 > 180) {
                hour = 3;
            }else if(minAfter15 > 240){
                hour = 4;
            }else if(minAfter15 > 300){
                hour = 5;
            }else if(minAfter15 > 360){
                hour = 6;
            }else if(minAfter15 > 420){
                hour = 7;
            }else if(minAfter15 > 480){
                hour = 8;
            }else if(minAfter15 > 540){
                hour = 9;
            }else if(minAfter15 > 600){
                hour = 10;
            }else if(minAfter15 > 660){
                hour = 11;
            }else if(minAfter15 > 720){
                hour = 12;
            }else if(minAfter15 > 780){
                hour = 13;
            }else if(minAfter15 > 840){
                hour = 14;
            } else if(minAfter15 > 900){
                hour = 15;
            }else if(minAfter15 > 960){
                hour = 16;
            }else if(minAfter15 > 1020){
                hour = 17;
            }else if(minAfter15 > 1080){
                hour = 18;
            }else if(minAfter15 > 1140){
                hour = 19;
            }else if(minAfter15 > 1200){
                hour = 20;
            }else if(minAfter15 > 1260){
                hour = 21;
            }else if(minAfter15 > 1320){
                hour = 22;
            }else if(minAfter15 > 1380){
                hour = 23;
            }else if(minAfter15 > 1440){
                hour = 24;
            }

            if(minAfter15 == 60){
                minAfter15 = 0;
            }



            if(minAfter15 > 59){
                minAfter15 = minAfter15 - 60;
            }

            if(hour == 24){
                hour = 0;
            }

            if(minAfter15 < 10){
                System.out.println(hour + ":" + 0 + minAfter15);
            }else {
                System.out.println(hour + ":" + minAfter15);
            }
        }
    }
