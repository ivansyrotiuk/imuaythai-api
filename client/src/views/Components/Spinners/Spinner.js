import React, {Component} from 'react';


export default class Spinner extends Component {
  render() {
    return <div class="row align-items-center">
        <div class="col">
            <div className="row justify-content-center">
                <div className="span-12">
                    <i class="fa fa-cog fa-spin fa-3x fa-fw"></i>
                </div>
            </div>
        </div>
    </div>
  }
}