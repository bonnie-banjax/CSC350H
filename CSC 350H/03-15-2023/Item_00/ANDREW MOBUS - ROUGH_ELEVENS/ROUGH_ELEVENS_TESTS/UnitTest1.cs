using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ROUGH_ELEVENS;
namespace ROUGH_ELEVENS_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        //-----------------------------------------------------------|-----------------------------------------------------------

        [TestMethod]         // "Ol_Reliable"
        // this is a trasnposition of the basic run test I used
        // during development; the difference is that was from the
        // the CORE main file, and produces output to the console,
        // which I used for debugging; the test serves as a goal
        // by which I could know whether the auto solver worked.

        // The reason for such a high iteration count is, to put
        // it one way, because that's what automated testing is
        // good for. Some of the errors and bugs I caught were
        // only clear because they persisted over such a large
        // iteration count.
        
        // The simplest was just that no wins after 10k games
        // meant my solver didn't work, but a better example was
        // to see that the remaining cards were consistently 
        // the higher value cards. This turned out to be due to
        // the List<T> collection behavior; when elements are
        // removed from the collection, it changes size, which
        // changed the indexes, which could & would remove the
        // wrong cards. The bug depended on the order of card
        // submission - if the higher index card was removed
        // first, the system would work as intended.
        
        // As a result, this bug would be difficult, not to
        // meantion laborious, to first spot, then recreate,
        // if manually testing -- and that's assuming it's
        // discovered at all. Another bug the auto solver
        // uncovered was that I hadn't considered what would
        // happen if the player attempted to submit the same
        // card index; I found this bug when manually playing
        // through and finding that the game didn't end even
        // though there didn't appear to be any valid moves.

        // However, the game otherwise often seem to work
        // as intended and correctly determined the end state
        // for many other games. I used the manual auto option
        // to step through the moves of a game, and when I 
        // confirmed the bug replication, I went back, and
        // did the same thing but used the IDE breakpoints
        // to step through on an ever finer detail scale &
        // see what the submitted indexes were for the move.
        // At this point I discovered & addressed the edge
        // case, after which the auto solver and end game
        // state detector (these use the same algorithm)
        // worked as desired.

        public void TM_000()
        {
            HOUSE theHouse = new();
            theHouse.DaRules.Elevens();
            bool exitCon = false;
            for (int i = 0; exitCon != true && i < 10000; i++)
            {
                theHouse.PlayLoop(theHouse.DaRules);
                if (theHouse.Audit.Last.action == "[V]")
                    exitCon = true;
            }
            Assert.IsTrue(theHouse.Audit.Last.action == "[V]"); //deliberately not casting as string for comparison
        } // END_TEST

        //-----------------------------------------------------------|-----------------------------------------------------------

        [TestMethod]         // "TenThousandVictories"
        // based on the Ol_Reliable test, the conidtion is flipped; the
        // loop will exit if any of the games are lost. In normal Elevens
        // this wouldn't work, but the "table size" has been increased
        // to the entire deck (52 cards, hence "Elevens_52()" for rules)
        // which means, if auto solver works, 10k victory are assured.
        
        // This was likkely my most important test, and reflects the
        // benefits and power of TTD. While I didn't run the test using
        // the framework provided here (I did all of the testing with
        // the source files, which also means a lot (or all) of the test
        // process state code was lost when I refactored; ie, this is
        // a concise recreation of the test & its objectives, but is
        // that concise because it relies on features, like the logger
        // and RULESET struct method, which were not yet developed

        public void TM_001()
        {
            HOUSE theHouse = new();
            theHouse.DaRules.Elevens_52();
            bool exitCon = false;
            for (int i = 0; exitCon != true && i < 10000; i++)
            {
                theHouse.PlayLoop(theHouse.DaRules);
                if (theHouse.Audit.Last.action == "[F]")
                    exitCon = true;
            }
            Assert.IsTrue(theHouse.Audit.Last.action == "[V]");
            Assert.IsTrue(theHouse.Audit.LogCount == 10000);
        } // END_TEST

        //-----------------------------------------------------------|-----------------------------------------------------------

        [TestMethod]          // "TenThousandDefeats"
        // Converse of "TenThousandVictories" (if the name didn't give it away
        // This test validates the system by changing the hand size to 2, which
        // means there's no way to win. Putting asside the unlikely event that
        // all cards happened to be stacked in pairs, there's no way to submit
        // the face card triad. Again, the large iteration count is partially
        // to show off a kind of test enable by the (non explicitly, or even
        // implicitly) required autosolver. This isn't particularly representive
        // of any particular test I ran during development; the ValidMoveExists
        // function was one of the first to come online, and was pretty easy to
        // get the baseline minimum -- if it didn't find and end to the game,
        // the game would stall, after all. I've included it both to pad the 
        // test count so that these giant blocks of green text are broken up
        // by something, and are anchored in a genuine TTD process; while I may
        // not have exactly used this test, its one I could have used, and is
        // moreso useful moving forwards for insuring no breaking changes occur
        // since, if this test fails, one knows theres a leak somewhere.

        // Maintaining code is just as important as writing code (for the most part),
        // and is usually where most developers struggle; or, at least, its a problem
        // that must always be addressed. I've sought to keep the code as clean as
        // possible, but some of what I've learned with this process has been about
        // documentation & maintainability / sustainability. The write up cover this
        // a bit more in depth so I won't say too much more about that here.

        // As a final note, I want to recognize that the three tests here rely on
        // a lot of code which I tested to validate (the individual indexer functions,
        // the logger system) and therefore implicitly test that these things still
        // work, but ideally all of the component tests (which were all things I did,
        // but mutably in the source code) would have been documented, if only to
        // record what the test goals & conditions were themselves.


        public void TM_002()
        {
            HOUSE theHouse = new();
            theHouse.DaRules.Elevens_02();
            bool exitCon = false;
            for (int i = 0; exitCon != true && i < 10000; i++)
            {
                theHouse.PlayLoop(theHouse.DaRules);
                if (theHouse.Audit.Last.action == "[V]")
                    exitCon = true;
            }
            Assert.IsTrue(theHouse.Audit.Last.action == "[F]");
            Assert.IsTrue(theHouse.Audit.LogCount == 10000);
        } // END_TEST

        //-----------------------------------------------------------|-----------------------------------------------------------
    }
}