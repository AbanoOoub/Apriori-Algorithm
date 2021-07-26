# Apriori-Algorithm
Algorithm Steps:<br/>
<ul>
<li>Generate frequent 1-itemsets</li>
<li>Repeat until no itemsets can be generated:</li>
	<ul>
		<li>Generate candidate itemsets.<br/></li>
		<li>Candidate Pruning.</li>
		<li>Calculate support.</li>
		<li>Support pruning.</li>
	</ul>
</ul>

<ul>
	<li>Generate strong rules:</li>
	<ul>
		<li>Start with frequent 2-itemsets.</li>
		<li>Generate combinations of rules.</li>
		<li>Keep strong rules.</li>
	</ul>	
</ul>

NOTE: If you have Transaction Data like:</br>
[TID - Itemset]		   </br>
  1  - Tomato,Pepsi,Bread  </br>
  2  - Pepsi,Bread	   </br> 
  3  - Bread,Eggs	   </br>
  4  - Milk,Bread	    
  5  - Milk,Eggs,Tomato    </br>  
  
Then you should enter it in left Grid as:</br>
[TID - Itemset]</br>
  1  - T,P,B </br>
  2  - P,B   </br> 
  3  - B,E   </br>
  4  - M,B   
  5  - M,E,T   
  
  
