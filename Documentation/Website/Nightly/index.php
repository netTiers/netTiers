<?
	function list_files($where)
	{
		if(is_dir($where)) 
		{
			$thisdir = dir($where);
			while($entry=$thisdir->read()) 
			{
    			if(($entry!='.')&&($entry!='..')&&($entry!='index.php'))
				{
					$result.= "<li><a href=$where/$entry>$entry</a></li>";
				}
			}
		}
		return $result;
	}

?>

<? include("../inc.top.php"); ?>

					<h3>Nightly build downloads</h3>
					This is developpement files, no warranty that it works ;-)<br><br>
					<? echo list_files("."); ?>

<? include("../inc.bottom.php"); ?>