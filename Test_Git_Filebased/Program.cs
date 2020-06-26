using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Git_Filebased
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = CreateRepository(@"C:\Filebased\TestRep");
            r.Commit("commit1", new Signature(new Identity("prudhvi-muvvala-444", "muvvala.prudhvi@gmail.com"), DateTimeOffset.Now),
                new Signature(new Identity("prudhvi-muvvala-444", "muvvala.prudhvi@gmail.com"), DateTimeOffset.Now));
            CreateBranch(r, "branch1");
            CreateBranch(r, "branch2");

            Console.Read();

        }

        private static Repository CreateRepository(string path)
        {
            Repository r = null;
            try
            {
                if (!Repository.IsValid(path))
                {
                    string repPath = Repository.Init(path);
                    r = new Repository(repPath);
                }
                else
                {
                    r = new Repository(path);
                }
            }
            catch(Exception ex)
            {

            }
            return r;
        }


        private static Branch CreateBranch(Repository r, string branchName)
        {
            Branch b = null;
            try
            {
                BranchCollection branches = r.Branches;
                if(branches[branchName] == null)
                {
                    b = r.CreateBranch(branchName);
                }
            }
            catch(Exception e)
            {

            }
            return b;
        }
    }
}
