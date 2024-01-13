using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player orkPlayer = new Player("ork", new UndeadProvider(new BarbarianClassProvider(new OrcRaceProvider(), 2), 2));
            orkPlayer.PrintStat();

            var humanPlayer = new Player("human", new GeniousProvider(new WizardClassProvider(new HumanRaceProvider(), 2), 2));
            humanPlayer.PrintStat();

            var elfPlayer = new Player("elf", new PerfectReactionProvider(new ThiefClassProvider(new ElfRaceProvider(), 2), 2));
            elfPlayer.PrintStat();
        }
    }
}