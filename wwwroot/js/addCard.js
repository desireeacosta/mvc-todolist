function validateForm() {
  var cardName = document.getElementById("nameInput").value.trim();

  if (cardName === "") {
    alert("Please enter a valid card name.");
    return false;
  }
  return true;
}