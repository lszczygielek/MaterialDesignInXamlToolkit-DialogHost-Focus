# MaterialDesignInXamlToolkit-DialogHost-Focus

Repository contains example code which demo issue related with `DialogHost` in **MaterialDesignInXamlToolkit**.

When dialog is confirmed using keyboard (ENTER key), then `TextBox` doesn't update view model.

**Workaroud**  
Bind using `UpdateSourceTrigger=PropertyChanged`.
