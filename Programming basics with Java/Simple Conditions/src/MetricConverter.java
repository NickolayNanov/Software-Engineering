import java.util.Scanner;
public class MetricConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double input = Double.parseDouble(scanner.nextLine());

        String sourceMetric = scanner.nextLine();
        String destMetric = scanner.nextLine();


        if ("mm".equals(sourceMetric)) {
            input = input / 1000;
        } else if ("cm".equals(sourceMetric)) {
            input = input / 100;
        } else if ("mi".equals(sourceMetric)) {
            input = input / 0.000621371192;
        } else if ("in".equals(sourceMetric)) {
            input = input / 39.3700787;
        } else if ("km".equals(sourceMetric)) {
            input = input / 0.001;
        } else if ("ft".equals(sourceMetric)) {
            input = input / 3.2808399;
        } else if ("yd".equals(sourceMetric)) {
            input = input / 1.0936133;
        }

        if ("mm".equals(destMetric)) {
            input = input * 1000;
        } else if ("cm".equals(destMetric)) {
            input = input * 100;
        } else if ("mi".equals(destMetric)) {
            input = input * 0.000621371192;
        } else if ("in".equals(destMetric)) {
            input = input * 39.3700787;
        } else if ("km".equals(destMetric)) {
            input = input * 0.001;
        } else if ("ft".equals(destMetric)) {
            input = input * 3.2808399;
        } else if ("yd".equals(destMetric)) {
            input = input * 1.0936133;
        }

        System.out.printf("%.8f", input, destMetric);
    }
}
