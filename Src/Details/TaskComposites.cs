// Doc/Reference/Task.md
#if !(UNITY_EDITOR || DEBUG)
#define AL_OPTIMIZE
#endif


using Tag = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using Active.Core.Details;
using P  = System.Runtime.CompilerServices.CallerFilePathAttribute;
using M  = System.Runtime.CompilerServices.CallerMemberNameAttribute;
using L  = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using S  = System.String;

namespace Active.Core{
partial class Task{

    #if !AL_BEST_PERF
    #if !AL_THREAD_SAFE

    #if AL_OPTIMIZE

    public Seq Seq(bool repeat=true, [Tag] int key=-1)
    => store.Seq(key).Step(repeat);

    public Sel Sel(bool repeat=true, [Tag] int key=-1)
    => store.Sel(key).Step(repeat);

    #else  // AL_OPTIMIZE

    public Seq Seq(bool repeat=true, [P] S p="", [M] S m="",
                                                 [Tag] int key=-1)
    => store.Seq(key).Step(repeat, (p, m, key));

    public Sel Sel(bool repeat=true, [P] S p="", [M] S m="",
                                                 [Tag] int key=-1)
    => store.Sel(key).Step(repeat, (p, m, key));

    #endif  // end-(!)AL_OPTIMIZE

    protected Comp @do{get{
          Comp x = Comp.stack.Peek();
          return (x is Seq) ? (Comp) Active.Core.Seq.task
                            : (Comp) Active.Core.Sel.task;
    }}

    #endif  // end !AL_THREAD_SAFE
    #endif  // end !AL_BEST_PERF

}}