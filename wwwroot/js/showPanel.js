const togglePanelVisibility = (id) => {
    const element = document.getElementById(id);

    console.log("test");

    if (element.classList.contains("hidden")) {
        element.classList.remove("hidden");
    } else {
        element.classList.add("hidden");
    }
};
