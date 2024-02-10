let i = 0;
function timedCount() {
  i = i + 1;
  const a = {
    'time':new Date(),
    'num':i
  };
  postMessage(a);

  setTimeout("timedCount()",1000);
}

timedCount();