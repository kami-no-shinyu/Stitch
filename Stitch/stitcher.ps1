# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##
# Author : Kwesicoder                                                #
# This script takes a txt file which lists all rmd files, knits them #
# And returns which ones stitched and which didn't                   #
# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##

# Parameter is the path to the input file that has paths of all RMD
Param(
    [string]$file
)

# Get the info of the input txt file
$txt_contents = Get-Content "$file"

$failed_operations = @()
$success_operations = @()

# Each line in the input txt file is a path to an RMD file
foreach ($line in $txt_contents) {

    # Read in the actual file from the filepath in the line
    $rmd_file = Get-Item $line
    
    # Check if file is rmd by checking the extension
    if ($rmd_file.Extension -eq '.rmd') {
        
        #Replace with / so that rmarkdown can work with it
        $rmd_path = $rmd_file.FullName.Replace("\","/") 
        $rmd_base_name = ($rmd_file.DirectoryName + '/' + $rmd_file.BaseName).Replace("\","/")
       
        $output_path = ($rmd_base_name + '.docx')
        
        # Run R script on it, to do actual scripting
        & Rscript -e "rmarkdown::render('$rmd_path',output_file='$output_path');" > $null
        
        # Check if an error occurred or not and put this file in the corresponding list
        if ($LASTEXITCODE -ne 0) {
            $failed_operations += $rmd_file.FullName
        }
        else {
            $success_operations += $rmd_file.FullName 
        }
    }
}

if ($failed_operations.Length -gt 0 -Or $success_operations.Length -gt 0) {
    $failed_operations | Out-File -FilePath ($file + "-fail")
    $success_operations | Out-File -FilePath ($file + "-succeed")
}