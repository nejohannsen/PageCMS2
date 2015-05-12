var PageContent = React.createClass({
    getInitialState: function() {
        return {
            page: [], 
            working: true
        };
    },
    updateLocal: function(data) {
        var page = this.state.page
        page.Title = data
        this.setState({page: page})
    },
    componentWillMount: function() {
        this.loadPageFromServer();
    },
    UpdateDataOnServer: function(data) {
        $.ajax({
            url: this.props.submitUrl,
            dataType: 'json',
            type: 'PATCH',
            data: data,
            success: function(data) {
                this.setState({data: data});
            }.bind(this),
            error: function(xhr, status, err) {
                /* console.error(this.props.url, status, err.toString());*/
            }.bind(this)
        });
    },
    loadPageFromServer: function() {
        $.ajax({
            url: "/pages/reactjson/1",
            dataType: 'json',
            type: 'GET',
            success: function(data) {
                this.setState({page: JSON.parse(data), working:false});
                console.log(this.state)
            }.bind(this),
            error: function(xhr, status, err) {
                /* console.error(this.props.url, status, err.toString());*/
            }.bind(this)
        });
    },
    render: function() {
        return (
            <div>
                {this.state.working ? (
                    <Working />
                ) : (null)}
              <div className="PageContent"></div>
                    <LeftColumn 
                        page={this.state.page}
                        updateLocal={this.updateLocal}
                    />
                    <RightColumn />
              </div>
      );
    }
});

var Working = React.createClass({
    render: function() {
        return (
            <div id="working"></div>
        );
    }
});

var LeftColumn = React.createClass({
    getInitialState: function() {
        return {
            edit: false
        };
    },
    handleClick: function() {
        this.setState({edit: true})
    },
    handleChange: function(e) {
        this.props.updateLocal(React.findDOMNode(this.refs.title).value)
    },
    handleDone: function() {
        this.setState({edit: false})
    },
    render: function() {
        return (
          <div className="leftColumn">
            {this.state.edit ? (
                <div>
                    <input ref="title" onChange={this.handleChange} defaultValue={this.props.page.Title} /><a href="#" onClick={this.handleDone}>Done</a>
                </div>
            ) : (
                <div>
                    <p onClick={this.handleClick}>{this.props.page.Title}</p>
                </div>
            )}
          </ div>
        );
    }
});

var RightColumn = React.createClass({
    render: function() {
        return (
          <div className="rightColumn">

          </div>
      );
    }
});
React.render(
  <PageContent />,
  document.getElementById('content')
);