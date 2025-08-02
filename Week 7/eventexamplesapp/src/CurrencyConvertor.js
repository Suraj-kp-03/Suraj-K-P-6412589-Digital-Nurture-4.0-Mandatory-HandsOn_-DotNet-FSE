import React from 'react'

 function InrToEuro({...data}){
    const euro = (parseFloat(data.value) / 101).toFixed(2);
    alert(`Converting to ${data.currency} Amount is ${euro}`);
}


    function submitForm(data){
        const value=data.get("value");
        const currency=data.get("currency");
        const convert={value:value,currency:currency};
        InrToEuro({...convert});
      }
      
function CurrencyConvertor() {
  return (
    <div>
        <h1 style={{color:"green"}}> Currency Convertor!!</h1>

        <form action={submitForm}>
        <label>Amount: </label>
        <input type='number' name='value'></input>
        <br />
        <label>Currency: </label>
        <input type='text' name='currency'></input>
        <br />
            <div style={{ textAlign: 'left', paddingLeft:'100px'}}>
               <button type="submit">Submit</button>
            </div>
    </form>
    </div>
  )
}

export default CurrencyConvertor