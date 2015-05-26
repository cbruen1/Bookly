//describe('When verifying the Jasmine environment', function () {
//    it('should run a true test', function () {
//        expect(true).toBe(true);
//    })
//})

describe('When querying the Breeze web api', function () {
    'use strict';

    var fns = window.testFns;
    var EntityQuery = breeze.EntityQuery;
    var tester, em;     // em = entity manager
    var failed = fns.failed;

    beforeEach(function () {
        //tester = ngMidwayTester('BreezeWebApiTest');
        //em = new breeze.EntityManager(fns.serviceName);
        em = new breeze.EntityManager(fns.serviceBase + fns.serviceName);
    });

    afterEach(function () {
        //tester.destroy();
        //tester = null;
    });

    it('should get at least one order', function (done) {
        testQuery("Orders", success, done);

        function success(data) {
            var results = data.results;
            expect(results.length).toBeGreaterThan(0);
        }
    });

    it('should get at least one book', function (done) {
        testQuery("Books", success, done);

        function success(data) {
            var results = data.results;
            expect(results.length).toBeGreaterThan(0);
        }
    });

    it('should find an order with its details', function (done) {
        testQuery("Orders", success, done, addToQuery);

        function addToQuery(query) {
            return query.top(1).expand('OrderDetails');
        }

        function success(data) {
            var results = data.results;
            expect(results.length).toBe(1);
            var order = results[0];
            var details = order.OrderDetails;
            expect(details.length).toBeGreaterThan(0);
        };
    });

    it('should find a specific book with id 2', function (done) {
        testQuery("Orders", success, done, addToQuery);

        function addToQuery(query) {
            return query.where('id', 'eq', 2);
        };

        function success(data) {
            var results = data.results;
            expect(results.length).toBe(1);
        };
    });

    function testQuery(resourceName, success, done, addToQuery) {
        var query = EntityQuery.from(resourceName)
            .using(em);

        if (addToQuery) {
            query = addToQuery(query);
        }
        query.execute()
            .then(success)
            .catch(failed)
            .finally(done);
    }
})

