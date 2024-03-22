using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class was created to test whether could use switch statements to
// super-optimize the process but really the validation is so simple
// that the validate set function should be a method of the ruleset

// maybe change from static to (well, a singleton ?)
// lazy initalization (make a static variable so works like
// mCopy of Heque where the first caller constructs & then everyone
// else that should have these functions (and would call to make one)
// gets a reference to where the existing instance lives

// [03-07-2024] copied the code into a new Struct without
// all the documentation in order to keep things tidy
// just feels right having it be a struct since its really
// just a collection of methods, and having be a struct
// encourages composition over inheritence
// no real overhead since it doesn't have any data of
// its own so double check how that interacts with
// (static tag, in regards to methods and structs

// structs are also potentially more condusive to the command
// design pattern in that classes are (not sure how to describe)
// simultaniously more and less generalized; the gist is that
// everything the validator does is just a (static) function
// and while their (are only a few dependencies), between the 
// methods, they are overall pretty decoupled, and are entirely
// decopupled from the data that they process, but still make sense
// to group together in some regard, which a struct does perfectly

namespace ROUGH_ELEVENS
{

    // difference between abstract & static (?)
    // arguement for instancing in that it would allow (specific circumstance)
    // but already does that with dependancy injection (?)
    public class Validator //may return to static class
    {
        // -----------------------------------------------------------|-----------------------------------------------------------

        // this is the abstracted version of initial validator; by using
        // and array for the values, the same function can be used for
        // for pairs (array size of 2, check == 11) & the triad
        // (array size of 3, checkCon = 36)

        static public bool validate_set(int[] vals, int check) // validate_sum (?)
        {
            int sum = 0;
            foreach (int val in vals)
                sum += val;

            if (sum == check)
                return true;
            else
                return false;
        } // END_FUNC

        // this set validator checks to see if any pair meets the criteria
        // and exits its nested loops as soon as flag is set true

        // -----------------------------------------------------------|-----------------------------------------------------------
        // rename find_index_pair
        static public int[] find_pair_index(int[] valArray, int checkCon)
        {
            if (valArray == null)
                return [-1, -1];

            for (int i = 0; (i < valArray.Length); i++)
                for (int ii = 0; (ii < valArray.Length); ii++)
                    if ( (valArray[i] + valArray[ii] == checkCon) && (valArray[i] != valArray[ii]) )
                        return [i, ii];
            return [-1, -1]; // really want to only return [-1]
        }

        // rename find_index_triad (could do three binary search calls (?))
        static public int[] find_triad_index(int[] valArray, (int a, int b, int c) faces) // 11, 12, 13
        {

            if (valArray == null)
                return [-1, -1, -1];

            bool[] checks = [false, false, false];
            int[] nDexes = [-1, -1, -1];
            for (int i = 0; i < (valArray.Length); i++)
            {
                if (valArray[i] == faces.a)
                {
                    nDexes[0] = i;
                    checks[0] = true;
                }
                if (valArray[i] == faces.b)
                {
                    nDexes[1] = i;
                    checks[1] = true;
                }
                if (valArray[i] == faces.c)
                {
                    nDexes[2] = i;
                    checks[2] = true;
                }
            } // END_FOR

            if (checks[0] == true
            && checks[1] == true
            && checks[2] == true)
                return nDexes;
            else { return [-1, -1, -1];  }

        }


        // this doesn't properly return a releveant index
        // fixed the index issue; this can search for the prsence of more
        // than just triad, but rather, the total presence of an exception set
        // ie can be represented as group of particular discrete values (?)
        static public int[] find_indexi(int[] valArray, int[] faceArray) // 11, 12, 13
        {
            List<int> nDexes = valArray.ToList();
            
            foreach (var value in faceArray) {
                nDexes.Add(SearAlgo(valArray, value));
                if (nDexes.Last() == (-1))
                    return [-1];
            } // END_FOR

            return nDexes.ToArray();
        }

        // currently linear search, since binary sort will only
        // if whatever is drawing indexes from is already sorted
        // and that may or may not be viable
        static int SearAlgo(int[] arg, int look) // no reason to be public 
        {
            for (int i = 0; i < arg.Length; i++)
                if (arg[i] == look)
                    return i;
            return -1;
        }

        // found (general, standard; not generic) binary search
        public static object BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }

        // not sure why took things had broken into seperate functions and brought back all toghether
        // including the fact that it not long skips the triad check if it finds a pair condition, which
        // was part of what make the method more sophisticated, but need to clear up old tangled methods
        // and this one insures there is a single, function method for checking, given a valarray, if 
        // any pair or triad moves exists (so more in functional programming side) (input & output solid)
        public static bool valid_move_exists(int[] valArray, int checkCon, (int a, int b, int c) faces) // validate_sum (?)
        {
            //-----
            bool flag_00; ;
            bool flag_01 = false;
            bool flag_02 = false;

            //-----
            // seperate back out into own function or use find_pair_index
            // uses flag_01
            for (int i = 0; i < (valArray.Length) && (flag_01 == false); i++)
                for (int ii = 0; (ii < valArray.Length) && (flag_01 == false); ii++)
                    if ((valArray[i] + valArray[ii] == checkCon) && (valArray[i] != valArray[ii]))
                    { flag_01 = true; }
                    
            //-----
            // seperate back out into own function or use refactor find_triad_index
            // uses flag_02
            bool[] checks = [false, false, false];
            for (int i = 0; i < (valArray.Length); i++)
            {
                if (valArray[i] == faces.a)
                    checks[0] = true;
                if (valArray[i] == faces.b)
                    checks[1] = true;
                if (valArray[i] == faces.c)
                    checks[2] = true;
            } // END_FOR

            if (checks[0] == true
             && checks[1] == true
             && checks[2] == true)
                flag_02 = true;

            //-----

            if (flag_01 == true || flag_02 == true)
            { flag_00 = true; }
            else
            { flag_00 = false; }

            return flag_00;
        } // END_FUNC

        //-----------------------------------------------------------|-----------------------------------------------------------



    } // end_class

}

/*
 
    const int validCon = 11;
    int pairCon = 11;
    int triadCon = 36;

    bool validate_00((int a, int b) val, int check)
    {

        switch (val.a+val.b)
        {
            case validCon:
                return true;
            default:
                return false;
        } // end_switch
    } // ED_FUNC

    // these might be slower, but in this case that's trivial
    bool validate_pair((int a, int b) val, int check)
    {

        if (val.a + val.b == check)
            return true;
        else
            return false;
    } // END_FUNC

    bool validate_triad((int a, int b, int c) val, int check)
    {

        if (val.a + val.b + val.c == check)
            return true;
        else
            return false;
    } // END_FUNC

 
 
 
 
 
 */

/*
for (int i = 0; i < (faceArray.Length) && flag == false; i++)
{
    nDexes[i] = SearAlgo(valArray, faces.a);
    if (nDexes[i] == (-1))
        flag = true;
} // END_FOR

nDexes[0] = SearAlgo(valArray, faces.a);
if (nDexes[0] == (-1))
    return nDexes; // early escape because no triad

nDexes[1] = SearAlgo(valArray, faces.b);
if (nDexes[1] == (-1))
    return nDexes; // early escape because no triad

nDexes[2] = SearAlgo(valArray, faces.c);
if (nDexes[2] == (-1))
    return nDexes; // early escape because no triad


return nDexes;
*/
