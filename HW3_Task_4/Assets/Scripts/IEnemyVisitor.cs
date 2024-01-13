public interface IEnemyVisitor
{
    void Visit(Orc ork);
    void Visit(Human human);
    void Visit(Elf elf);
    void Visit(Enemy enemy);
}