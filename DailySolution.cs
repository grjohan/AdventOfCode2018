namespace ConsoleApp6 {
    public interface DailySolution<Part1Type, Part2Type> {
        Part1Type Part1();

        Part2Type Part2();
    }
}