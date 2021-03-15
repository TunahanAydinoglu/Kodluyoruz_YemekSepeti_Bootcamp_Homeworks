import React,{Component} from 'react';

class AddButton extends Component {
    render(){
        return (
                <button className="btn btn-success" onClick={this.props.eklemeFonksiyonu} >Ekle</button>
        )
    }
}
export default AddButton;